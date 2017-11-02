import { Component, EventEmitter, OnInit,Output } from '@angular/core';
import { ContactService } from '../services/contact.service';
import { Contact } from '../contact';
  
@Component({
  selector: 'app-contact-list',
  templateUrl: './contact-list.component.html',
  styleUrls: ['./contact-list.component.css']
})
export class ContactListComponent implements OnInit {

  title: string;
  contacts: Contact[];
  contact: Contact;
  contactSelected: Contact;
  isValidInput: Boolean;
  
  constructor(private contactService: ContactService) {
    this.title = 'Contacts List';
    this.contacts = this.contactService.getContacts();
    this.isValidInput = false;
    this.contact = new Contact();
   }

  ngOnInit() {}

  onContactSelect(contact: Contact) {
    this.contactSelected = contact;
  }

  onRemoveSelect(contact: Contact){
    this.contactService.deleteContact(contact);
    this.contactSelected = null;
  }
  
  onAddNewContact() {
    if(this.contact.firstName && this.contact.lastName && this.contact.phone && this.contact.gender
      && this.contact.streetAddress && this.contact.city) {
        this.contactService.addContact(this.contact);
        this.contact.firstName = "";
        this.contact.lastName = "";
        this.contact.phone = "";
        this.contact.streetAddress = "";
        this.contact.city = "";
        this.isValidInput = false;      
    } else {
       this.isValidInput = true;      
      }
  }

}
