export class Contact {
    
      id: number;
      firstName: string;
      lastName: string;
      phone: string;
      gender: number; //0 = female, 1 = male
      avatar: string; //02  04 06   03 11 05  
      streetAddress: string;
      city: string;

      constructor(id?:number, firstName?:string, lastName?:string,
        phone?:string, gender?:number, avatar?:string, streetAddress?:string,city?:string){
        this.id = id;
        this.firstName = firstName;
        this.lastName = lastName;
        this.phone = phone;
        this.gender = gender;
        this.avatar = avatar;
        this.streetAddress = streetAddress;
        this.city = city;
      }
    }
    