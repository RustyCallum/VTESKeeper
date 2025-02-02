import { Pipe, PipeTransform } from '@angular/core';
@Pipe({
  name: 'playerFilter'
})
export class PlayerFilterPipe implements PipeTransform {

  transform(value: any, args?: any): any {
    if (!args) {
      return value;
    }

    args = args.toLowerCase();

    return value.filter((val: {vekn: string; firstName:string; lastName:string;}) => {
      let rVal = (val.vekn.toLowerCase().includes(args) || val.firstName.toLowerCase().includes(args) || val.lastName.toLowerCase().includes(args));
      return rVal;
    })

  }

}