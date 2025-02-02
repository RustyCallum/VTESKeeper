import { Pipe, PipeTransform } from '@angular/core';
@Pipe({
  name: 'nameFilter'
})
export class NameFilterPipe implements PipeTransform {

  transform(value: any, args?: any): any {
    if (!args) {
      return value;
    }

    args = args.toLowerCase();

    return value.filter((val: { city: string; name: string; date:string }) => {
      let rVal = (val.city.toLocaleLowerCase().includes(args)) || (val.name.toLocaleLowerCase().includes(args)) || (val.date.toLocaleLowerCase().includes(args));
      return rVal;
    })

  }

}