import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ChartModule } from 'primeng/chart';
import { MenuModule } from 'primeng/menu';
import { TableModule } from 'primeng/table';
import { ButtonModule } from 'primeng/button';
import { StyleClassModule } from 'primeng/styleclass';
import { PanelMenuModule } from 'primeng/panelmenu';
import { DataViewModule } from 'primeng/dataview';
import { FeedComponent } from './feed.component';
import { FarcasterClientRoutingModule } from './farcaster-client-routing.module';

@NgModule({
    imports: [
        CommonModule,
        FormsModule,
        ChartModule,
        MenuModule,
        TableModule,
        StyleClassModule,
        PanelMenuModule,
        ButtonModule,
        DataViewModule,
        FarcasterClientRoutingModule
    ],
    declarations: [FeedComponent]
})
export class FarcasterClientModule { }
