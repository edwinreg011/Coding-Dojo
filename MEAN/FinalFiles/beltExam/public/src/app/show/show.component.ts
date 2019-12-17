import { Component, OnInit } from '@angular/core';
import { HttpService } from '../http.service';
import { ActivatedRoute, Params, Router } from '@angular/router';

@Component({
  selector: 'app-show',
  templateUrl: './show.component.html',
  styleUrls: ['./show.component.css']
})
export class ShowComponent implements OnInit {

  constructor(
    private _httpService: HttpService,
    private _router : Router,
    private _route : ActivatedRoute
  ) { }

  viewPet: any;

  ngOnInit() {
    this._route.params.subscribe((params: Params) => {
      this.getViewPet(params["id"]);
    })
  }

  getViewPet(id){
    let obs = this._httpService.getOnePet(id);
    obs.subscribe(data => {
      if(data["results"]){
        this.viewPet = data["results"];
      }
    })
  }

  destroyOnePet(id){
    let obs = this._httpService.destroyPet(id);
    obs.subscribe(data => {
      if(data["results"]){
        this._router.navigate(['/']);
      }
    })
  }
}
