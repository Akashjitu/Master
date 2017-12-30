import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {NoopAnimationsModule} from '@angular/platform-browser/animations';
import { AppComponent } from './app.component';
import { MainLogingComponent } from './main-loging/main-loging.component';
import { MainFoodsComponent } from './main-foods/main-foods.component';
import { FinderComponent } from './finder/finder.component';
import {TabsModule} from "ng2-tabs";

@NgModule({
  declarations: [
    AppComponent,
    MainLogingComponent,
    MainFoodsComponent,
    FinderComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    NoopAnimationsModule,
    TabsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
