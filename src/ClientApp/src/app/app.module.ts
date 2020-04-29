import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { FormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { PanelListComponent } from './panel-list/panel-list.component';
import { HomeComponent } from './home/home.component';
import { PanelDetailComponent } from './panel-detail/panel-detail.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    PanelListComponent,
    PanelDetailComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    AppRoutingModule,
    NgbModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
