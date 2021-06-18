import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'PhoneFormat'
})
export class PhonePipe implements PipeTransform {

  transform(value: any, args?: any): any {
    return value.replace(/(\d{2})(\d{1})(\d{4})(\d{4})/g, '\($1) \$2 \$3\-\$4');
  }

}
