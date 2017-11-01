import { Injectable } from '@angular/core';
import { User } from './user';
import * as _ from "lodash";

@Injectable()
export class UserService {

  private users: User[];
  constructor() { 
    this.users = [
      new User(1,'testi', 'erkkilä'),
      new User(2,'juuso', 'moikkala'),
      new User(3,'Kari', 'vesanen')
    ];
  }

  getUser(): User[] {
    return this.users || [];
  }

  AddUser(user: User) {
    if(this.users.length > 0) {
      var k = 0;
      k = _.maxBy(this.users, function(o) { return o.id; }).id;
      k++;user.id = k;
      this.users.push(Object.assign({}, user));
    } else {
      this.users.push(Object.assign({}, new User(0,user.firstName, user.lastName)));
    }
  }

  DeleteUser(user) {
    this.users.splice(_.findIndex(this.users, function(o) { return o.id == user.id; }),1);
  }
  

}
