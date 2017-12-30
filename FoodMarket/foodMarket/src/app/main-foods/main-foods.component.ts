import { Component, OnInit, trigger, state, style, transition, animate } from '@angular/core';
import {Food} from '../entity/food';

@Component({
  selector: 'app-main-foods',
  templateUrl: './main-foods.component.html',
  styleUrls: ['./main-foods.component.css'],
  animations: [trigger('flipState', [
    state('active', style({
      transform: 'rotateY(179.9deg)'
    })),
    state('inactive', style({
      transform: 'rotateY(0)'
    })),
    transition('active => inactive', animate('500ms ease-out')),
    transition('inactive => active', animate('500ms ease-in'))
  ])
  ]
})
export class MainFoodsComponent implements OnInit {

  searchfood: string;
  foods: Food[];


 
  constructor() {}

 

  ngOnInit() {
    this.showAll();
}

   showAll() {
    this.foods = [ 
      new Food('https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTWkG-zR9XE_kEuUlb4STiri2ARZkePw1Rx_NdJf2Eag5q81SiAOw', 100 ,  'Choolet' , 11, 'food', 'RamLal'),
      new Food('https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTWkG-zR9XE_kEuUlb4STiri2ARZkePw1Rx_NdJf2Eag5q81SiAOw', 100 ,  'Choolet' , 11, 'food', 'RamLal'),
      new Food('https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTWkG-zR9XE_kEuUlb4STiri2ARZkePw1Rx_NdJf2Eag5q81SiAOw', 100 ,  'Choolet' , 11, 'food', 'RamLal'),
      new Food('https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTWkG-zR9XE_kEuUlb4STiri2ARZkePw1Rx_NdJf2Eag5q81SiAOw', 100 ,  'Choolet' , 11, 'food', 'RamLal'),
      new Food('https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTWkG-zR9XE_kEuUlb4STiri2ARZkePw1Rx_NdJf2Eag5q81SiAOw', 100 ,  'Choolet' , 11, 'food', 'RamLal'),
      new Food('https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTWkG-zR9XE_kEuUlb4STiri2ARZkePw1Rx_NdJf2Eag5q81SiAOw', 100 ,  'Choolet' , 11, 'food', 'RamLal'),
      new Food('https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTWkG-zR9XE_kEuUlb4STiri2ARZkePw1Rx_NdJf2Eag5q81SiAOw', 100 ,  'Choolet' , 11, 'food', 'RamLal'),
      new Food('https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTWkG-zR9XE_kEuUlb4STiri2ARZkePw1Rx_NdJf2Eag5q81SiAOw', 100 ,  'Choolet' , 11, 'food', 'RamLal'),
      new Food('https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTWkG-zR9XE_kEuUlb4STiri2ARZkePw1Rx_NdJf2Eag5q81SiAOw', 100 ,  'Choolet' , 11, 'food', 'RamLal')

    ];
   }
}
