import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { FormsModule } from '@angular/forms';
import { UserListComponent } from './user/user-list/user-list.component';
import { UserInfoComponent } from './user/user-info/user-info.component';

import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import {MatButtonModule, MatIconModule, MatInputModule, MatListModule} from '@angular/material';
import { UserService } from './user/user.service';
import * as _ from "lodash";

@NgModule({
  declarations: [
    AppComponent,
    UserListComponent,
    UserInfoComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    BrowserAnimationsModule,
    MatButtonModule,
    MatInputModule,
    MatIconModule,
    MatListModule
  ],
  providers: [ UserService ],
  bootstrap: [ AppComponent ]
})
export class AppModule { }
