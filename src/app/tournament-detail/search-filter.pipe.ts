import { Pipe, PipeTransform } from '@angular/core';
@Pipe({
  name: 'allTournamentFilter'
})
export class allTournamentFilterPipe implements PipeTransform {

  transform(value: any, args?: any): any {
    if (!args) {
      return value;
    }

    args = args.toLowerCase();

    return value.filter((val: { name:string, vekn:string, round:number}) => {
      let rVal = (val.name.toLocaleLowerCase().includes(args)) || val.round == args || (val.vekn.toLocaleLowerCase().includes(args));
      console.log("ran");
      return rVal;
    })

  }

}