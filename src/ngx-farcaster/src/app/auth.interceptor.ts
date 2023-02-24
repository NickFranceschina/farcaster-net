import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent, HttpErrorResponse, HttpResponse } from '@angular/common/http';
import { Observable, of, throwError } from 'rxjs';
import { mergeMap, catchError, tap, filter, map } from 'rxjs/operators';
import { WalletService } from './wallet.service';

@Injectable({
  providedIn: 'root'
})
export class FcAuthInterceptor implements HttpInterceptor {
  constructor(private walletService: WalletService) { }

    
  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {

    const fcConnected = this.walletService.checkFarcasterConnected();
    if (fcConnected) {
        const fcAuthToken = localStorage.getItem('fcAuthToken') as string;
        req = req.clone({ headers: req.headers.set('fc-bearer-token', fcAuthToken) });        
    }

    return next.handle(req);
  }

}
