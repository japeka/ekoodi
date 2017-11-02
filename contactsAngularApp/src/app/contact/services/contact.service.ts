import { Injectable } from '@angular/core';
import { Contact } from '../contact';
import * as _ from "lodash";

@Injectable()
export class ContactService {

  private contacts: Contact[];
  private avatars: string[][];
  private avatarUrl: string;
  constructor() {
   this.avatars = [['02','04','06'],['03','11','05']]; 
   this.avatarUrl = 'http://svgavatars.com/style/svg/';
   this.contacts = this.getContactsFromStorage();
   }

   storeContactsToStore() {
      if(this.contacts) {
        localStorage.removeItem('contacts');
        localStorage.setItem('contacts',JSON.stringify(this.contacts));
      } else {
        localStorage.removeItem('contacts');
      }
   }

   getContactsFromStorage(): Contact[] {
    if (typeof(Storage) !== "undefined") {
      if(localStorage.getItem('contacts') != null) {
        return JSON.parse(localStorage.getItem('contacts'));
      }
    } 
    return [];
   }

   getAvatarPicture(gender: number) {
    let position = Math.floor(Math.random() * 3) 
    return this.avatarUrl + this.avatars[gender][position] + '.svg';
   }
   
   getContacts(): Contact[] {
    var json = JSON.stringify(this.contacts);
    return this.contacts || [];
  }

  deleteContact(contact: Contact): void {
    this.contacts.splice(_.findIndex(this.contacts, function(o) { return o.id == contact.id; }),1);
    this.storeContactsToStore();
  }

  addContact(contact: Contact): void {
    if(this.contacts.length > 0) {
      var k = 0;
      k = _.maxBy(this.contacts, function(o) { return o.id; }).id;
      k++;contact.id = k;
      contact.avatar = this.getAvatarPicture(contact.gender);
      this.contacts.push(Object.assign({}, contact));

    } else {
      this.contacts.push(Object.assign({}, new Contact(0,contact.firstName, contact.lastName,
      contact.phone,contact.gender,this.getAvatarPicture(contact.gender),contact.streetAddress, contact.city)));
    }
    this.storeContactsToStore();
  }
  

}
