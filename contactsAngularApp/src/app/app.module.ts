import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import { FormsModule } from '@angular/forms';
import {MatButtonModule, MatIconModule, MatInputModule, MatListModule,MatExpansionModule,MatCardModule,MatRadioModule} from '@angular/material';
import * as _ from "lodash";

import { ContactListComponent } from './contact/contact-list/contact-list.component';
import { ContactListItemComponent } from './contact/contact-list/contact-list-item/contact-list-item.component';
import { ContactService } from './contact/services/contact.service';

@NgModule({
  declarations: [
    AppComponent,
    ContactListComponent,
    ContactListItemComponent
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
    MatRadioModule
  ],
  providers: [ContactService],
  bootstrap: [AppComponent]
})
export class AppModule { }