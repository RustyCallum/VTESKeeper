import { Pipe, PipeTransform } from '@angular/core';
@Pipe({
  name: 'leagueFilter'
})
export class LeagueFilterPipe implements PipeTransform {

  transform(value: any, args?: any): any {
    if (!args) {
      return value;
    }

    args = args.toLowerCase();

    return value.filter((val: {name: string; points: number; }) => {
      let rVal = (val.name.toLocaleLowerCase().includes(args) || val.points == args);
      return rVal;
    })

  }

}