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
                                    <p-avatar [image]="cast.author.pfpUrl" size="large" shape="circle"></p-avatar>
                                    {{ cast.firstOpenGraphAttachment?.strippedCastText ?? cast.text }}
                                    <img 
                                        class="my-4 md:my-0 w-9 md:w-10rem shadow-2 mr-5"
                                        *ngIf="!!cast.firstOpenGraphAttachment?.image || !!cast.firstOpenGraphAttachment?.logo" 
                                        [src]="cast.firstOpenGraphAttachment?.image ?? cast.firstOpenGraphAttachment?.logo" 
                                    />                                    
                                </div>
                            </div>
                        </ng-template>
                        <ng-template let-cast pTemplate="gridItem">
                            <div class="col-12 md:col-4 xl:col-3">
                                <div class="card m-3 border-1 surface-border">
                                    <div class="flex flex-wrap gap-2 align-items-center justify-content-between mb-2">
                                        <div class="flex align-items-center">
                                            <p-avatar class="mr-2" [image]="cast.author.pfpUrl" size="large" shape="circle"></p-avatar>
                                            <span class="font-semibold">{{cast.author.displayName}}</span>
                                        </div>
                                        <span>{{ cast.timestamp | timeago }}</span>
                                    </div>
                                    <div class="flex flex-column align-items-center text-center mb-3">
                                        {{ cast.firstOpenGraphAttachment?.strippedCastText ?? cast.text }}
                                        <img 
                                            class="w-9 shadow-2 my-3 mx-0"
                                            *ngIf="!!cast.firstOpenGraphAttachment?.image" 
                                            [src]="cast.firstOpenGraphAttachment?.image" 
                                        />
                                    </div>
                                    <div class="flex align-items-center justify-content-between">
                                        <button pButton pRipple type="button" [label]="cast.repliesCount"  icon="pi pi-comments" class="p-button-sm p-button-rounded p-button-outlined"></button>
                                        <button pButton pRipple type="button" [label]="cast.reactionsCount"  icon="pi pi-heart" class="p-button-sm p-button-rounded" [class.p-button-outlined]="!cast.viewerContextReacted"></button>
                                        <button pButton pRipple type="button" [label]="cast.recastsCount"  icon="pi pi-replay" class="p-button-sm p-button-rounded" [class.p-button-outlined]="!cast.viewerContextRecast"></button>
                                    </div>                                    
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
