import { Component, OnInit } from '@angular/core';
import {BreakpointObserver, Breakpoints} from '@angular/cdk/layout';
import { DomSanitizer } from '@angular/platform-browser';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';
import { ContactService } from '../services/contact.service';
import { Contact } from '../contact'; 

@Component({
  selector: 'app-contact-details',
  templateUrl: './contact-details.component.html',
  styleUrls: ['./contact-details.component.css']
})
export class ContactDetailsComponent implements OnInit {
  contact: Contact;
  btnName: string;
  isInValidInput: Boolean;
  errorMessage: String;
  showRemoveBtn: Boolean;
  staticUrl: String;
  breakpointObserver: BreakpointObserver;
  isSmallScreen: Boolean;

  constructor(
    private contactService: ContactService,
    private route: ActivatedRoute,
    private router: Router,
    public sanitizer: DomSanitizer,
    breakpointObserver: BreakpointObserver    
  ) {
    this.contact = new Contact(); 
    this.isInValidInput = false;
    this.errorMessage = "";
    this.btnName = "Add New Contact";
    this.showRemoveBtn= false;
    this.isSmallScreen = false;
    this.breakpointObserver = breakpointObserver;
  }

  ngOnInit() {
    this.breakpointObserver.observe([
      '(max-width: 584px)'
    ]).subscribe(result => {
      this.isSmallScreen = result.matches;
    });
    let id = this.route.snapshot.paramMap.get('id');
    if(id!==null) { //find for existing contact
      this.contact = this.contactService.findContactById(Number(id));
      this.btnName = "Edit Contact";
      this.showRemoveBtn= true;
    } 
  }

  isValidPhoneNumber(number: string): Boolean {
    if(number) {
      return /^\d{2,3}-?\d{4,15}$/.test(number);
    } else {
      return false;
    }
  }

  onContactRemove(): void {
    this.contactService.deleteContact(this.contact);
    this.router.navigate(['/contacts']);
  }

  onClickContactEvent(): void {
    if(this.contact.id===undefined) {
      if(this.contact.firstName && this.contact.lastName && this.contact.phone && this.contact.gender
        && this.contact.streetAddress && this.contact.city) {
          if(!this.isValidPhoneNumber(this.contact.phone)) {
            this.errorMessage = "Please provide valid phone number. 01-234567 for instance.";
            this.isInValidInput = true;      
          } else {
            this.contactService.addContact(this.contact);
            let cId = this.contact.id;
            this.contact.firstName = "";
            this.contact.lastName = "";
            this.contact.phone = "";
            this.contact.streetAddress = "";
            this.contact.city = "";
            this.isInValidInput = false;   
            this.router.navigate(['/contacts']);
          }

        } else {
          this.errorMessage = "Please provide input for your firstname, lastname, phone number, gender, street address and city";
          this.isInValidInput = true;      
        }
    } else {
      if(!this.isValidPhoneNumber(this.contact.phone)) {
        this.errorMessage = "Please provide valid phone number. 01-234567 for instance.";
        this.isInValidInput = true;      
      } else {
        this.contactService.updateContact(this.contact);
        //this.router.navigate(['/contacts/'+this.contact.id]);
        this.router.navigate(['/contacts']);
        }
    }
  }
}
