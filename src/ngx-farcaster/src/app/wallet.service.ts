import { Injectable } from '@angular/core';
import { ethers } from 'ethers';
import { Buffer } from 'buffer';
import { HttpClient } from '@angular/common/http';
import { firstValueFrom } from 'rxjs';
const canonicalize = require('canonicalize');

@Injectable({
  providedIn: 'root'
})
export class WalletService {
  public ethereum;
  public account: string = '';

  constructor(private httpClient: HttpClient) {
    const {ethereum} = <any>window;
    this.ethereum = ethereum;
  }

  public checkWalletInstalled = () => !!this.ethereum && this.ethereum.isMetaMask;
  public checkFarcasterConnected = () => !!localStorage.getItem('fcAuthToken');


  public checkWalletConnected = async () => {
    // shortcut
    if (!this.ethereum) return false;

    try{
        const accounts = await this.ethereum.request({method: 'eth_accounts'});
        this.account = accounts[0] ?? '';
        return accounts.length > 0;
    }
    catch(e){
        console.error('could not fetch accounts', e);
        return false;
    }
  }

  public connectWallet = async () => {
    try{
      const accounts = await this.ethereum.request({method: 'eth_requestAccounts'});
      return accounts;
    }
    catch(e){
      console.error('could not connect to wallet', e);
      return [];
    }
  }

  public getFcAuthToken = async () => {
    if (!localStorage.getItem('fcAuthToken')) {
        // A Web3Provider wraps a standard Web3 provider, which is
        // what MetaMask injects as window.ethereum into each page
        const provider = new ethers.providers.Web3Provider(this.ethereum);
        await provider.send("eth_requestAccounts", []);
        const signer = provider.getSigner();
        const account = await signer.getAddress();
        console.log("Account:", account);
        const currentTimestamp = Date.now();
        const payload = canonicalize({
            method: 'generateToken',
            params: { 
                timestamp: currentTimestamp,
            },
        });
        console.log("payload :", payload );
        const signedPayload  = await signer.signMessage(payload);
        console.log("signedPayload :", signedPayload );
        const signature = Buffer.from(ethers.utils.arrayify(signedPayload)).toString('base64');
        console.log("signature :", signature );
        const custodyBearerToken = `eip191:${signature}`;
        console.log("bearerToken :", custodyBearerToken);
        // make an HTTP request with the bearer token
        const headers = {
            'Authorization': `Bearer ${custodyBearerToken}`,
            'Content-Type': 'application/json',
        };
        const response: any = await firstValueFrom(this.httpClient.put('https://api.warpcast.com/v2/auth', payload, {headers}));
        const appBearer = response.result.token.secret;
        console.log("appBearer :", appBearer);
        localStorage.setItem('fcAuthToken', appBearer);
    } 
    return localStorage.getItem('fcAuthToken');
  }
  
}