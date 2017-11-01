import { Component } from '@angular/core';
import {User} from './user/user';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Ang Test';
  myMsg = 'Hello World!'; 
  selectedUserName: string;
  constructor() {
    this.selectedUserName = 'ekoodi';
  }

  doIt(msg) {
    console.log(msg);
  }
  
  changeName(): void {
      this.selectedUserName = 'kooEedi';
  }
  
  onUserSelected(user: User) {
      this.selectedUserName = user.firstName + ' ' + user.lastName;
      //console.log(this.selectedUserName);
  }
}
