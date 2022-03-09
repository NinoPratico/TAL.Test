export class CalculateDeathPremiumRequest {
  constructor(
    public Name: string = '',
    public DateOfBirth: Date = new Date(),
    public Age: number = 0,
    public Occupation: string = '',
    public SumInsured: number = 0
  ) { }
}

export class CalculateDeathPremiumResponse {
  constructor(
    public Premium: number = 0,
    public Error: string = ''
  ) { }
}
