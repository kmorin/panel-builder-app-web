import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { PanelListComponent } from './panel-list/panel-list.component';
import { HomeComponent } from './home/home.component';
import { PanelDetailComponent } from './panel-detail/panel-detail.component';


const routes: Routes = [
  // {path: '', component: HomeComponent, pathMatch: 'full'},
  {path: '', component: PanelListComponent, pathMatch: 'full'},
  {path: 'panels', component: PanelListComponent, pathMatch: 'full'},
  {path: 'panels/:id', component: PanelDetailComponent, pathMatch: 'full'},
  {path: '**', redirectTo: '', pathMatch: 'full'}
];

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forRoot(routes)],
  exports: [
    RouterModule]
})
export class AppRoutingModule { }
