import { Component, OnInit } from '@angular/core';
import { HttpService } from '../http.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-new',
  templateUrl: './new.component.html',
  styleUrls: ['./new.component.css']
})
export class NewComponent implements OnInit {

  constructor(
    private _httpService: HttpService,
    private _router : Router,
  ) { }

  newPet: any;
  errors = [];

  ngOnInit() {
    this.newPet = {
      name: '',
      type: '',
      description: '',
      skill1: '',
      skill2: '',
      skill3: ''
    }
  }

  createPet(){
    this.errors =[];
    let obs = this._httpService.createPet(this.newPet);
    obs.subscribe(data => {
      if(data["results"]){
        this._router.navigate(['/']);
      }
      else if(data["errors"]){
        for(var key in data["errors"]){
          this.errors.push(data["errors"][key]["message"]);
        }
      }
    })
  }
}
