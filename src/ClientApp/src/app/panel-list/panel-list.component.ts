import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { IPanel } from '../panel-detail/IPanel';
import { Observable, throwError } from 'rxjs';
import { tap, catchError } from 'rxjs/operators';

@Component({
  selector: 'app-panel-list',
  templateUrl: './panel-list.component.html',
  styleUrls: ['./panel-list.component.css']
})
export class PanelListComponent implements OnInit {
 
  panels: IPanel[];
  private endpoint: string = '/api/panels';
  errorMessage: string;

  constructor(private http: HttpClient) {
   }

  ngOnInit(): void {
    //Fetch panels
    this.getPanels().subscribe({
      next: panels => {
        this.panels = panels;
      },
      error: err => this.errorMessage = err
    });
  }
  
  //Panels service
  getPanels(): Observable<IPanel[]> {
    return this.http.get<IPanel[]>(this.endpoint).pipe(
      tap(data=>console.log(data)),
      catchError(this.handleError)
    );
  }
  handleError(err: HttpErrorResponse){
    return throwError(err.error.message);
  }

}


