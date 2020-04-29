import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { IPanel } from './IPanel';

@Component({
  selector: 'app-panel-list',
  templateUrl: './panel-list.component.html',
  styleUrls: ['./panel-list.component.css']
})
export class PanelListComponent implements OnInit {
 
  panels: IPanel[];

  constructor(http: HttpClient) {
    const endpoint = '/api/panels';
    //IPanel[]
    http.get<IPanel[]>(endpoint).subscribe(res=>{
      this.panels = res;
      console.log("hay, this is angular on: "+ endpoint);
    }, err => console.log(err));
   }

  ngOnInit(): void {
  }
}


