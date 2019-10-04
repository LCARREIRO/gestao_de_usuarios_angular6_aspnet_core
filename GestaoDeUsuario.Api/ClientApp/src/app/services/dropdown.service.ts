import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { Sexo } from '../models/usuario-model';

@Injectable({
  providedIn: 'root'
})
export class DropdownService {

  private BASE_URL: string = 'https://localhost:44349/v1/sexo';

  constructor(private http: Http) { }

  getSexo(): Observable<Sexo[]> {
    return this.http.get(this.BASE_URL)
      .pipe(map((res: Response) => res.json()));
  }
}
