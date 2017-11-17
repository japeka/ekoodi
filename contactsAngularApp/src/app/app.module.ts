import { BrowserModule } from '@angular/platform-browser';
import { DomSanitizer } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule } from '@angular/forms';
import { MatButtonModule, MatIconModule, MatInputModule, MatListModule,MatExpansionModule,MatCardModule,MatRadioModule} from '@angular/material';
import { MatToolbarModule } from '@angular/material';
import { MatSidenavModule } from '@angular/material';
import { MatTooltipModule } from '@angular/material';
import { MatSnackBarModule } from '@angular/material';
import { FlexLayoutModule } from '@angular/flex-layout';
import { LayoutModule } from '@angular/cdk/layout';

import * as _ from "lodash";

//components
import { AppRoutingModule } from './app-routing/app-routing.module';
import { ContactListComponent } from './contact/contact-list/contact-list.component';
import { ContactListItemComponent } from './contact/contact-list/contact-list-item/contact-list-item.component';
import { ContactDetailsComponent } from './contact/contact-details/contact-details.component';
import { MapComponent } from './map/map/map.component';
import { LoginComponent } from './user/login/login.component';

//services
import { ContactService } from './contact/services/contact.service';
import { AuthenticationService } from './user/services/authentication.service';
import { SharedService } from './shared/shared.service';

//guard
import { AuthenticationGuard } from './guard/authentication.guard';

//pipes
import { ContactAddressPipe } from './contact/pipes/contact-address.pipe';
import { NgPipesModule } from 'ngx-pipes';
import { SafePipe } from './contact/pipes/safe.pipe';
import { CustomSortPipe } from './contact/pipes/custom-sort.pipe';



@NgModule({
  declarations: [
    AppComponent,
    ContactListComponent,
    ContactListItemComponent,
    ContactDetailsComponent,
    ContactAddressPipe,
    SafePipe,
    MapComponent,
    CustomSortPipe,
    LoginComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    BrowserAnimationsModule,
    MatButtonModule,
    MatInputModule,
    MatIconModule,
    MatListModule,
    MatExpansionModule,
    MatCardModule,
    MatRadioModule,
    MatTooltipModule,
    MatSidenavModule,
    MatSnackBarModule,
    FlexLayoutModule,
    LayoutModule,
    AppRoutingModule,
    NgPipesModule
  ],
  providers: [
    ContactService,
    AuthenticationService,
    AuthenticationGuard,
    SharedService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }