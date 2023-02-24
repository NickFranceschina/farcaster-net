import { Component, ElementRef, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { MenuItem } from 'primeng/api';
import { WalletService } from '../wallet.service';
import { LayoutService } from "./service/app.layout.service";

@Component({
    selector: 'app-topbar',
    templateUrl: './app.topbar.component.html'
})
export class AppTopBarComponent implements OnInit, OnDestroy {

    items!: MenuItem[];
    walletInstalled: boolean = false;
    walletConnected: boolean = false;
    walletId: string = '';
    fcConnected: boolean = false;

    @ViewChild('menubutton') menuButton!: ElementRef;

    @ViewChild('topbarmenubutton') topbarMenuButton!: ElementRef;

    @ViewChild('topbarmenu') menu!: ElementRef;

    constructor(public layoutService: LayoutService, private walletService: WalletService) { }

    async ngOnInit() {
        this.walletInstalled = this.walletService.checkWalletInstalled();
        this.walletConnected = await this.walletService.checkWalletConnected();
        this.fcConnected = this.walletService.checkFarcasterConnected();
        this.walletId = this.walletService.account;
    }

    connectToWallet = async () => {
        const accounts = await this.walletService.connectWallet();
        if(accounts.length > 0){
            this.walletConnected = true;
            this.walletId = accounts[0];
        }
    }

    getAuthToken = async () => {
        const token = await this.walletService.getFcAuthToken();
        console.log("token :", token);
    }

    ngOnDestroy() {
    }

}
