import { Component } from '@angular/core';
import { WebApiClient, Cast } from './webapi.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'ngx-farcaster';

  casts: Cast[] = [];

  constructor(private webapi: WebApiClient) {
    webapi.defaultFeed().subscribe(c => {
      this.casts = c;
    });
  }

}
