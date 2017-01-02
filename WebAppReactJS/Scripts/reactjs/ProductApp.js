class ProductApp extends React.Component{
        
    constructor(props) {
        super(props);
        this.refresh = this.refresh.bind(this);
        this.state = {products: [], isLoading: false, autoRefresh:true};            
    }
        
    componentDidMount() {            
        if(this.state.autoRefresh == false)
            this.getProducts();            
        else
            setInterval(this.refresh, 5000);
    }

    refresh(){            
        this.getProducts();
    }
    
    getProducts(){            
        if(this.state.isLoading)return;
        this.setState({isLoading: true}); 

        $.getJSON('/Home/GetProducts')
        .then((result) => {
            this.setState({ products: result, isLoading: false });
        });
    }

    render() {
        return (
            <div>
            <h3>Products</h3>
            <ProductList products={this.state.products} />
            </div>
        );
    }
}

class ProductList extends React.Component{
    render() 
    {
        return (
            <ul>
            {this.props.products.map(item => (
                
                <li key={item.Id}><a href={'/Home/product/' + item.Id}>{item.Name}</a> - ${item.Price}</li>
            ))}
        </ul>
        );
    }
}

ReactDOM.render(<ProductApp />, document.getElementById('container-product'));     
