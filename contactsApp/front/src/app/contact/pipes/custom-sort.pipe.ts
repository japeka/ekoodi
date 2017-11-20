import { Pipe, PipeTransform } from '@angular/core';
import * as _ from "lodash";
@Pipe({
  name: 'customSort'
})
export class CustomSortPipe implements PipeTransform {
  transform(myArray: any, args?: any): any {
    if(args==='gender')
      return _.sortBy(myArray, o => o.gender.toLowerCase());
    else if (args==='firstName') 
      return _.sortBy(myArray, o => o.firstName.toLowerCase());
    else if (args==='lastName') 
      return _.sortBy(myArray, o => o.lastName.toLowerCase());
    else if (args==='city') 
      return _.sortBy(myArray, o => o.city.toLowerCase());
    else 
      return myArray;
  }
}
