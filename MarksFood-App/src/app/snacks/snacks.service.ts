import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { take } from 'rxjs/operators';

import { Snack } from '../core/models/snack';

@Injectable({
  providedIn: 'root'
})
export class SnacksService {

  API = `${environment.API}/Snack`;
  
  constructor(private http: HttpClient) { }

  listSnacks(){
    return this.http.get<Snack[]>(this.API).pipe(take(1));
  }
  
}
