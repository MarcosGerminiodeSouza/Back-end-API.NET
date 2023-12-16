import { Component, OnInit } from '@angular/core';
import { LivrariaAPIServico } from './product-list.service';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit {

  livros: any;
  servicoLivraria : LivrariaAPIServico;

  constructor(  servicoLivros: LivrariaAPIServico) {
    this.servicoLivraria = servicoLivros;
  }

  ngOnInit(): void {
    this.livros = this.servicoLivraria.getBooks().subscribe((data => {
      this.livros = data;
      console.log(this.livros);
    }))
  }

}
