import { location } from "./location";
import { origin } from "./origin";

export class results
{
      id:number;
      name:string;
      status:string;
      species:string;
      type?:string;
      gender:string;
      origin:origin;
      location:location;        
      image:string;
      episode:string[];
}

