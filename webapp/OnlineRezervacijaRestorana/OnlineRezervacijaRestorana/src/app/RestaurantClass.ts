
export class Restaurant {
    constructor(
      
      public name: string ,
      public city_name: string ,
      public description: string ,
      public priceRange: number,
      public cityId?: number | undefined,
      public tables?: any,
    ) { }
   
}