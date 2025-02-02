import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'sizeFilter'
})
export class TableSizePipe implements PipeTransform {

  transform(list: any[], value: number) {
  

    return value ? list.filter(item => item.playerNumber >= value) : list;
  }

}