import { Component, OnInit, Input } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { IPanel } from './IPanel';

@Component({
  selector: 'app-panel-detail',
  templateUrl: './panel-detail.component.html',
  styleUrls: ['./panel-detail.component.css']
})
export class PanelDetailComponent implements OnInit {

  private endpoint: string = '/api/panels';
  private _panel: IPanel;

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
  }

  //Setup property to bind to the component. Needed to isolate
  @Input()
  set panel(panel: IPanel) {
    this._panel = panel;
  }
  get panel(): IPanel { return this._panel; }

  deletePanel(): void {
    alert("Are you sure to delete "+ this.panel.id);
    this.http.delete(this.endpoint+'/'+this._panel.id);
  }
}
