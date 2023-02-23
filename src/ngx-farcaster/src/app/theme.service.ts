import { Inject, Injectable } from '@angular/core';
import { DOCUMENT } from '@angular/common';

@Injectable({
    providedIn: 'root',
})
export class ThemeService {

    constructor(@Inject(DOCUMENT) private document: Document) {}

    public isDarkTheme: boolean = false;

    switchTheme(dark: boolean) {
        this.isDarkTheme = dark;
        let themeLink = this.document.getElementById('theme-link') as HTMLLinkElement;

        if (themeLink) {
            themeLink.href = (dark ? 'dark-purple' : 'light-purple') + '.css';
        }
    }
}
