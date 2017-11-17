import { Component, EventEmitter, OnInit,Output } from '@angular/core';
import { ContactService } from '../services/contact.service';
import { Contact } from '../contact';
import { Router } from '@angular/router';  

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

  constructor(private contactService: ContactService,private router: Router) {
    this.title = 'Contacts List';
    this.contacts = this.contactService.getContacts();
    this.contact = new Contact();
   }

  ngOnInit() {}

  onContactSelect(contact: Contact) {
    this.contactSelected = contact;
  }

  onRemoveSelect(contact: Contact) {
    this.contactService.deleteContact(contact);
    this.contactSelected = null;
  }

  addNewContact(): void {
    this.router.navigate(['/add-contact']);
  }
  
}
