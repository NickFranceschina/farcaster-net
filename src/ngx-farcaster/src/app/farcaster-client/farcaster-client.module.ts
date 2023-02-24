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
import { AvatarModule } from 'primeng/avatar';

import { FeedComponent } from './feed.component';
import { FarcasterClientRoutingModule } from './farcaster-client-routing.module';
import { TimeagoModule } from 'ngx-timeago';
import { BadgeModule } from 'primeng/badge';
import { ChipModule } from 'primeng/chip';

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
        AvatarModule,
        BadgeModule,
        ChipModule,
        TimeagoModule,
        FarcasterClientRoutingModule        
    ],
    declarations: [FeedComponent]
})
export class FarcasterClientModule { }
