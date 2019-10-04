import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { Usuario } from '../models/usuario-model';

@Injectable({
  providedIn: 'root'
})
export class UsuarioService {

  private BASE_URL: string = 'https://localhost:44349/v1/usuario';

  constructor(private http: Http) { }

  obterTodos(): Observable<Usuario[]> {
    return this.http.get(this.BASE_URL)
      .pipe(map((res: Response) => res.json()));
  }

  obterPorId(id: string): Observable<Usuario> {
    return this.http.get(`${this.BASE_URL}/${id}`)
      .pipe(map((res: Response) => res.json()));
  }

  delete(id:string) {
    return this.http.delete(`${this.BASE_URL}/${id}`)
      .pipe(map((res: Response) => res.json()));
  }

  salvar(usuario: Usuario) {    
    return this.http.post(this.BASE_URL, usuario)    
      .pipe(map((res: Response) => res.json()));    
  }

  atualizar(usuario: Usuario) {    
    return this.http.put(this.BASE_URL, usuario)
      .pipe(map((res: Response) => res.json()));
  }
}
