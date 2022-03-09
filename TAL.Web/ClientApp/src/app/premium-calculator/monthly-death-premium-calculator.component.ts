import { Component, Inject, OnInit } from '@angular/core';
import { MessageService } from 'primeng/api';

import * as moment from "moment";
import { PremiumCalculatorService } from '../Services/premium-calculator.service';
import { CalculateDeathPremiumRequest, CalculateDeathPremiumResponse } from '../Models/CalculateDeathPremiumRequest.class';
import { Occupation } from '../Models/Occupation.class';

@Component({
  selector: 'app-monthly-death-premium-calculator',
  templateUrl: './monthly-death-premium-calculator.component.html',
  styleUrls: ['./monthly-death-premium-calculator.component.css'],
  providers: [MessageService]
})
export class MonthlyDeathPremiumCalculatorComponent implements OnInit {
  public IsLoading: boolean = false;
  public Request: CalculateDeathPremiumRequest = new CalculateDeathPremiumRequest();
  public Response: CalculateDeathPremiumResponse = new CalculateDeathPremiumResponse();
  public IsCalcPremiumDisabled: boolean = true;
  public Occupations: Occupation[];
  public MaxDateOfBirth: Date;

  constructor(private messageService: MessageService,
    private Service: PremiumCalculatorService) {
  }

  ngOnInit() {
    this.Service
      .Init()
      .subscribe(result => {
        this.Occupations = result;
      },
      error => console.error(error));

    this.MaxDateOfBirth =
      this.Request.DateOfBirth =
    moment()
      .subtract(365, 'days')
        .startOf('day')
        .toDate();

    this.CalcAge();

    console.log('ngOnInit', this);
  }

  OnChange() {
    this.IsCalcPremiumDisabled = this.Request.Name === ''
      || this.Request.Occupation === ''
      || this.Request.SumInsured === 0
      || this.Request.Age === 0;
    console.log('OnChange', this);
  }

  CalcAge() {
    this.Request.Age = moment().diff(this.Request.DateOfBirth, 'years');
    console.log('CalcAge', this);
  }

  CalculatePremium() {
    console.log('CalculatePremium: ', this.IsCalcPremiumDisabled, this.Request);

    if (!this.IsCalcPremiumDisabled) {
      this.IsLoading = true;
      this.Service
        .CalcPremium(this.Request)
        .subscribe((result: CalculateDeathPremiumResponse) => {
          this.Response = result;
          console.log('CalcPremium', this.Response);
          if (result.Premium > 0)
            this.messageService.add({ severity: 'success', summary: 'DeathPremiumCalculator', detail: 'Premium has been calculated' });
          if (result.Error !== '')
            this.messageService.add({ severity: 'error', summary: 'Error: DeathPremiumCalculator', detail: result.Error });
          this.IsLoading = false;
        }, error => {
          console.error(error);
          this.messageService.add({ severity: 'error', summary: 'Error: DeathPremiumCalculator', detail: error });
          this.IsLoading = false;
        });
    }
  }
}
