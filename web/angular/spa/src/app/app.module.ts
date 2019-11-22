import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './header/header.component';
import { MainAreaComponent } from './main-area/main-area.component';
import { SideBarComponent } from './side-bar/side-bar.component';
import { FooterComponent } from './footer/footer.component';
import { HomeComponent } from './home/home.component';
import { NewsComponent } from './news/news.component';
import { AboutComponent } from './about/about.component';
import { ContactsComponent } from './contacts/contacts.component';
import { Routes, RouterModule } from '@angular/router';
import { OverviewComponent } from './overview/overview.component';
import { ReportsComponent } from './reports/reports.component';
import { AnalyticsComponent } from './analytics/analytics.component';
import { ExportComponent } from './export/export.component';
import { NotFoundComponent } from './not-found/not-found.component';

export const routes: Routes = [

  { path: '', component: MainAreaComponent, children: [ { path: '', component: HomeComponent } ] },
  { path: ':id', component: MainAreaComponent, children: [

    { path: 'home', component: HomeComponent },
    { path: 'news', component: NewsComponent },
    { path: 'about', component: AboutComponent },
    { path: 'contacts', component: ContactsComponent },
    { path: 'overview', component: OverviewComponent },
    { path: 'reports', component: ReportsComponent },
    { path: 'analytics', component: AnalyticsComponent },
    { path: 'export', component: ExportComponent }

  ] },
  { path: '**', component: MainAreaComponent, children: [ { path: '**', component: NotFoundComponent } ] }

];

@NgModule( {

  declarations: [
    AppComponent,
    HeaderComponent,
    MainAreaComponent,
    SideBarComponent,
    FooterComponent,
    HomeComponent,
    NewsComponent,
    AboutComponent,
    ContactsComponent,
    OverviewComponent,
    ReportsComponent,
    AnalyticsComponent,
    ExportComponent,
    NotFoundComponent
  ],
  imports: [ BrowserModule, AppRoutingModule, RouterModule.forRoot( routes ) ],
  providers: [],
  bootstrap: [ AppComponent ]

})
export class AppModule { }
