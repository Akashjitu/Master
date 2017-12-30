export class Food {
  image: string;
  cost: number;
  name: string;
  id: number;
  category: string;
  store: string


  constructor (image: string,
               cost: number,
               name: string,
               id: number,
               category: string,
               store: string) {
    this.image = image;
    this.cost = cost;
    this.name = name;
    this.id = id;
    this.category = category;
    this.store = store;
  }
}
