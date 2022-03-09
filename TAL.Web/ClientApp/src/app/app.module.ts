import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';

import { AutoCompleteModule } from "primeng/autocomplete";
import { CalendarModule } from "primeng/calendar";
import { ChipsModule } from "primeng/chips";
import { DropdownModule } from "primeng/dropdown";
import { InputMaskModule } from "primeng/inputmask";
import { InputNumberModule } from "primeng/inputnumber";
import { CascadeSelectModule } from "primeng/cascadeselect";
import { MultiSelectModule } from "primeng/multiselect";
import { InputTextareaModule } from "primeng/inputtextarea";
import { InputTextModule } from "primeng/inputtext";
import { TabViewModule } from 'primeng/tabview';
import { TableModule } from 'primeng/table';
import { TooltipModule } from 'primeng/tooltip';
import { ListboxModule } from 'primeng/listbox';
import { ToastModule } from 'primeng/toast';
import { RadioButtonModule } from 'primeng/radiobutton';
import { FileUploadModule } from 'primeng/fileupload';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';

import { MonthlyDeathPremiumCalculatorComponent } from './premium-calculator/monthly-death-premium-calculator.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    MonthlyDeathPremiumCalculatorComponent
  ],
  imports: [
    CommonModule,
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    BrowserAnimationsModule,
    HttpClientModule,
    FormsModule,

    AutoCompleteModule,
    CalendarModule,
    ChipsModule,
    DropdownModule,
    InputMaskModule,
    InputNumberModule,
    CascadeSelectModule,
    MultiSelectModule,
    InputTextareaModule,
    InputTextModule,
    TabViewModule,
    TableModule,
    TooltipModule,
    ListboxModule,
    ToastModule,
    RadioButtonModule,
    FileUploadModule,

    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'monthly-death-premium-calculator', component: MonthlyDeathPremiumCalculatorComponent },
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
