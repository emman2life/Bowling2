import { Component, OnInit } from '@angular/core';
import { BowlingScores } from '../model/bowling-scores';
import { BowlingService } from '../_services/bowling.service';

@Component({
  selector: 'app-bowling-game',
  templateUrl: './bowling-game.component.html',
  styleUrls: ['./bowling-game.component.css']
})
export class BowlingGameComponent implements OnInit {
  
  pins!: number[];
 bowlingScores: any;
  constructor(private bowlingServices: BowlingService) { }

  ngOnInit(): void {
    this.initBowl();
  }




  getPinsLeft(length: number): number[]{
    this.pins = new Array(length);
    for (let index = 0; index < this.pins.length; index++) {
      this.pins[index] = index+1;
      
    }
    return this.pins;
  }

  initBowl(){
    this.bowlingServices.initBowl().subscribe(response =>{
      this.bowlingScores = response;
    },error=>{
      console.log(error);
    })
  }
  bowl(model:any){
    this.bowlingServices.bowl(model).subscribe(response =>{
      this.bowlingScores = response;
    },error=>{
      console.log(error);
    })
  }
  

}
