import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormControl } from '@angular/forms';
import { UsuarioService } from 'src/app/services/usuario.service';
import { Router } from '@angular/router';
import { DropdownService } from 'src/app/services/dropdown.service';
import { Sexo } from 'src/app/models/usuario-model';


@Component({
  selector: 'app-usuario-cadastrar',
  templateUrl: './usuario-cadastrar.component.html',
  styleUrls: ['./usuario-cadastrar.component.css']
})
export class UsuarioCadastrarComponent implements OnInit {

  sexos: Sexo[];

  formulario: FormGroup

  constructor(
    private router: Router,
    private formBuilder: FormBuilder,
    private usuarioService: UsuarioService,
    private dropdownService: DropdownService,
  ) { }

  ngOnInit() {

    this.dropdownService.getSexo().subscribe(
      res => {
        this.sexos = res;
      },
      error => {
        alert(error);
      }
    );

    this.formulario = this.formBuilder.group({
      nome: [null, Validators.required],
      dataNascimento: [null, Validators.required],
      email: [null],
      senha: [null],
      sexo: [null, Validators.required],
      ativo:[true]
    })
  }

  salvar() {
    debugger
    if (this.formulario.valid == false) {
      alert('Preencha todos os campos do fomrulário');
      return;
    }

    if (this.formulario.valid)

      this.usuarioService.salvar(this.formulario.value).subscribe(
        res => {
          //this.router.navigate(['']),
          if (res.success == true)
            alert(res.message);
        },
        error => {
          var obj = JSON.parse(error._body);
          alert(obj.message);
        }
      );
  }

  formReset() {
    this.formulario.reset();
  }
}

