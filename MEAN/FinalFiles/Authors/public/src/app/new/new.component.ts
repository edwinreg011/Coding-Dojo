import { Component, OnInit, OnDestroy } from '@angular/core';
import { HttpService } from '../http.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-new',
  templateUrl: './new.component.html',
  styleUrls: ['./new.component.css']
})
export class NewComponent implements OnInit, OnDestroy {

  constructor(
    private _httpService: HttpService, 
    private _router: Router
    ) { }

  newAuthor: any;
  errors = []; 

  ngOnInit() {
    this.newAuthor = {
      name: '',
      book1: '',
      book2: '',
      book3: ''
    }
  }

  ngOnDestroy(){
    this.newAuthor = null;
  }

  createAuthor(){
    this.errors = [];
    let obs = this._httpService.createAuthor(this.newAuthor);
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
