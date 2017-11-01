import {Component, EventEmitter, OnInit, Output} from '@angular/core';
import {UserService} from '../user.service';
import {User} from '../user';

@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.css']
})
export class UserListComponent implements OnInit {

  title: string;
  users: User[];
  user: User;
  firstName: String;
  lastName: string;
  isValidInput: Boolean;
  
  @Output() userSelected: EventEmitter<User>;
  constructor(private userService: UserService) {
    this.title = 'User List';
    this.users = this.userService.getUser();
    this.userSelected = new EventEmitter();
    this.isValidInput = false;
    this.user = new User();
  }

  ngOnInit() {
    /* this.users = [
        new User('janne', 'kallio'),
        new User('juuso', 'meikäläinen'),
        new User('Kari', 'Kulmala')
        (click)="onUserSelect(user)"
    ];*/
  }

  onUserSelect(user: User) {
     this.userSelected.emit(user);
  }

  onRemoveSelect(user: User) {
   this.userService.DeleteUser(user);
  }

  onAddNewUser() {
    if (this.user && this.user.firstName == undefined || this.user.lastName == undefined) {
      this.isValidInput = true;      
    } else {
       this.userService.AddUser(this.user);
       this.user.firstName = "";
       this.user.lastName = "";
       this.isValidInput = false;      
      }
  }


}
