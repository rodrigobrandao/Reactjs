class OrderApp extends React.Component {

    constructor(props) {
        super(props);
        this.state = { orders: [], isLoading: false };
        
        this.refresh = this.refresh.bind(this);
        
    }

    componentDidMount() {            
        
        if(this.props.autoRefresh == false)
            this.getOrders();            
        else
            setInterval(this.refresh, 5000);
    }

    refresh(){            
        this.getOrders();
    }
    
    getOrders(){            
        if(this.state.isLoading)return;
        this.setState({isLoading: true}); 

        $.getJSON('/Home/GetOrders')
        .then((result) => {
            this.setState({ orders: result, isLoading: false });
        });
    }

    render() {
        return (
            <div>
            <h3>List Orders</h3>
            <OrderList orders={this.state.orders} />
            </div>
        );
            }
}

class OrderList extends React.Component{
    render() 
    {
        return (
             <ul>
             {this.props.orders.map(order => (                
                 <Order order={order} />
             ))}
         </ul>
         );
                 }
}

class Order extends React.Component{

    onOrderClick(e, id){
                
        console.log('e:', e);
        console.log('this is:', id);
        alert(1)
    }

    render() 
    {

        return (
                 
                <li key={this.props.order.Id}><a onClick={(e)=> this.onOrderClick(e, this.props.order.Id)} style={{cursor: 'pointer'}}>{this.props.order.Number}</a> - ${this.props.order.TotalPrice}
                <br/>State: {this.props.order.StateString}
                <br/>Date: {this.props.order.DateString}
                {this.props.order.Items.map(item => (<ul><OrderItem item={item} /></ul>))}
                </li>
                 
             );
                }
}

class OrderItem extends React.Component{
        
    render() 
    {
        
        return (
                 <li>Item nr. {this.props.item.ItemId} - {this.props.item.Product.Name} - {this.props.item.Product.Price} </li>
             );
    }
}


ReactDOM.render(<OrderApp autoRefresh={true} />, document.getElementById('container-order'));     