import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CalculateDeathPremiumRequest, CalculateDeathPremiumResponse } from '../Models/CalculateDeathPremiumRequest.class';
import { Occupation } from '../Models/Occupation.class';

@Injectable({
  providedIn: 'root'
})
export class PremiumCalculatorService {

  constructor(private http: HttpClient,
    @Inject('BASE_URL')
    private baseUrl: string) { }

  Init(): Observable<Occupation[]> {
    return this.http.get<Occupation[]>(`${this.baseUrl}DeathPremiumCalculator/Init`);
  }

  CalcPremium(Request: CalculateDeathPremiumRequest): Observable<CalculateDeathPremiumResponse> {
    return this.http.post<CalculateDeathPremiumResponse>(`${this.baseUrl}DeathPremiumCalculator/CalcPremium`, Request);
  }
}
