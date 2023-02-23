import { Component, OnInit, OnDestroy } from '@angular/core';
import { firstValueFrom } from 'rxjs';
import { Cast, WebApiClient } from '../webapi.service';

@Component({
    template: `
        <div class="grid">
            <div class="col-12">
                <div class="card">
                    <h5>Feed Me</h5>
                    <p-dataView #dv [value]="casts" [paginator]="false" [rows]="20" layout="grid">
                        <ng-template pTemplate="header">
                            <div class="flex flex-column md:flex-row md:justify-content-between gap-2">
                                <!-- 
                                <p-dropdown [options]="sortOptions" placeholder="Sort By Price" (onChange)="onSortChange($event)"></p-dropdown>
                                <span class="p-input-icon-left">
                                    <i class="pi pi-search"></i>
                                    <input type="search" pInputText placeholder="Search by Name" (input)="onFilter(dv, $event)">
                                </span>	
                                -->
                                <p-dataViewLayoutOptions></p-dataViewLayoutOptions>
                            </div>
                        </ng-template>
                        <ng-template let-cast pTemplate="listItem">
                            <div class="col-12">
                                <div class="flex flex-column md:flex-row align-items-center p-3 w-full">
                                    {{ cast.text }}
                                </div>
                            </div>
                        </ng-template>
                        <ng-template let-cast pTemplate="gridItem">
                            <div class="col-12 md:col-4">
                                <div class="card m-3 border-1 surface-border">
                                    {{ cast.text }}
                                </div>
                            </div>
                        </ng-template>
                    </p-dataView>
                </div>
            </div>
        </div>
    `,
})
export class FeedComponent implements OnInit, OnDestroy {

    casts: Cast[] = [];

    constructor(private webApiClient: WebApiClient) {
    }

    async ngOnInit() {
        this.casts = await firstValueFrom(this.webApiClient.defaultFeed());
    }

    ngOnDestroy() {
    }
}
