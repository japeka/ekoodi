import {Component, Input, Output,EventEmitter, OnInit} from '@angular/core';
import {User} from '../user';

@Component({
  selector: 'app-user-info',
  templateUrl: './user-info.component.html',
  styleUrls: ['./user-info.component.css']
})
export class UserInfoComponent implements OnInit {

  /* outer component gives input to child element */
  @Output() userRemoveSelected: EventEmitter<User>;
  @Input() user: User;
  constructor() { 
    this.userRemoveSelected = new EventEmitter();
  }
  ngOnInit() {
  }

  onRemoveSelect(user) {
    //console.log("Removessa");
    //console.log(user);
    this.userRemoveSelected.emit(user);
  }

}
