import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { BowlingScores } from '../model/bowling-scores';

@Injectable({
  providedIn: 'root'
})
export class BowlingService {
  baseurl = environment.apiUrl;
  constructor(private http:HttpClient) { }

  bowl(model:any){
    const headers = { 'content-type': 'application/json'}  
    const body=JSON.stringify(model);
    return this.http.post(this.baseurl+'bowling', model);
  }
  initBowl(){
    return this.http.get<BowlingScores>(this.baseurl+'bowling').pipe();
  }
}
