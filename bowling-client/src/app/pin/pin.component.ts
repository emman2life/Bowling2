import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { BowlingScores } from '../model/bowling-scores';
import { BowlingService } from '../_services/bowling.service';

@Component({
  selector: 'app-pin',
  templateUrl: './pin.component.html',
  styleUrls: ['./pin.component.css']
})
export class PinComponent implements OnInit {
  model:any = {};
  @Input()pin!: Number;
  @Output() scores = new EventEmitter();
  bowlingScores!: any;
 
  constructor(private bowlingServices: BowlingService) { }

  ngOnInit(): void {
  }

  bowl(){
    
  this.model.pins = this.pin;
    console.log(this.model)
    
 
      this.scores.emit(this.model);
  
  }
}
