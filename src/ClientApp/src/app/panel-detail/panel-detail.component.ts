import { Component, OnInit, Input } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { IPanel } from './IPanel';
import { Observable, throwError, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-panel-detail',
  templateUrl: './panel-detail.component.html',
  styleUrls: ['./panel-detail.component.css']
})
export class PanelDetailComponent implements OnInit {
  private endpoint: string = 'api/panels';
  panel: IPanel | undefined;

  errorMessage: string;

  constructor(private http: HttpClient,
    private route: ActivatedRoute,
    private router: Router) { 

    }

  ngOnInit(): void {
    const param = this.route.snapshot.paramMap.get('id');
    if (param){
      const id = +param;
      this.getPanel(id);
    }
  }

  getPanel(id: number) {
    this.getPanelAction(id).subscribe({
      next: panel => {
        if (panel === null){ this.router.navigate(['/panels'])}
        this.panel = panel 
      },
      error: err => this.errorMessage = err
    });
  }

  deletePanel(): void {
    this.deletePanelAction(this.panel.id).subscribe({
      next: p => this.router.navigate(['/panels'])
    });
  }

  /* Actions */
  getPanelAction(id: number): Observable<IPanel | undefined> {
    const url = `${this.endpoint}/${id}`;
    return this.http.get<IPanel>(url)
      .pipe(
        catchError(this.handleE)
      );
  }

  deletePanelAction(id: number): Observable<{}> {
    const url = `${this.endpoint}/${id}`; // DELETE api/heroes/42
    alert('deleting panel ' + this.panel.name);
    return this.http.delete(url)
      .pipe(
        catchError(this.handleE)
      );
  }

  handleE(err: HttpErrorResponse) {
    return throwError(err.error.message);
  }
}