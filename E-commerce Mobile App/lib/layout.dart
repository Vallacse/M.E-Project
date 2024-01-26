import 'package:flutter/material.dart';

class LayoutPage extends StatefulWidget {
  const LayoutPage({super.key, required this.title});

  final String title;

  @override
  State<LayoutPage> createState() => _LayoutPageState();
}

class _LayoutPageState extends State<LayoutPage>{
  int _selectedIndex = 0;

  void _onItemTap(int index){
    setState(() {
      _selectedIndex = index;
    });
  }
  
  @override
  Widget build(BuildContext context){
    return Scaffold(
      backgroundColor: const Color.fromARGB(255, 207, 191, 143),
      appBar: AppBar(
        backgroundColor: const Color.fromARGB(255, 179, 238, 155),
        title: Text(widget.title),
        centerTitle: false,
        toolbarHeight: 80.0,
        elevation: 10.0,
        shape: const RoundedRectangleBorder(borderRadius: BorderRadius.only(bottomLeft: Radius.circular(30.0),bottomRight: Radius.circular(30.0))),
        actions: <Widget>[
          IconButton(
            icon: const Icon(Icons.search_outlined,size: 30.0,),
            tooltip: 'Search',
            onPressed: () {
            },
          ),
          IconButton(
            icon: const Icon(Icons.shopping_cart_rounded,size: 30.0,),
            tooltip: 'Cart',
            onPressed: () {
            },
          ),
          IconButton(
            icon: const Icon(Icons.account_circle_rounded,size: 30.0,),
            tooltip: 'Profile',
            onPressed: () {
            },
          ),
        ],
      ),
      body: Container(
          child: const Text('This is Body Content',style: TextStyle(fontSize: 20.0),),
          height: double.infinity,
          width: double.infinity,
          margin: const EdgeInsets.all(10.0),
          padding: const EdgeInsets.all(10.0),
          alignment: Alignment.center,
          decoration: BoxDecoration(color: Color.fromARGB(255, 130, 229, 152), borderRadius: BorderRadius.all(Radius.circular(20.0)),
          border: Border.all(color: Colors.blue,width: 2.0),
      ),),

      drawer:Drawer(
        child: ListView(
          children:[
            DrawerHeader(
              decoration: const BoxDecoration(color: Color.fromARGB(255, 197, 226, 186)),
              child: Column(
                children: [
                  IconButton(
                    icon: const Icon(Icons.account_circle_rounded,size: 85.0,),
                    tooltip: 'Profile',
                    onPressed:(){
                      Navigator.pop(context);
                    }
                  ),
                  const Text('Account Name')
                ],
              )
            ),
            ListTile(
              leading: const Icon(Icons.home),
              title: const Text('Home'),
              onTap:(){
                Navigator.pop(context);
              },
            ),
            ListTile(
              leading: const Icon(Icons.shopping_cart),
              title: const Text('My Cart'),
              onTap:(){
                Navigator.pop(context);
              },
            ),
            ListTile(
              leading: const Icon(Icons.shop_rounded),
              title: const Text('My orders'),
              onTap:(){
                Navigator.pop(context);
              },
            ),
            ListTile(
              leading: const Icon(Icons.account_box_rounded),
              title: const Text('Checkout'),
              onTap:(){
                Navigator.pop(context);
              },
            ),
            ListTile(
              leading: const Icon(Icons.live_help_sharp),
              title: const Text('Help'),
              onTap:(){
                Navigator.pop(context);
              },
            ),
            Divider(
              color: Colors.blue.shade600,
              height: 20.0,
            ),
             ListTile(
              leading: const Icon(Icons.info),
              title: const Text('About'),
              onTap:(){
                Navigator.pop(context);
              },
            ),
            ListTile(
              leading: const Icon(Icons.location_on),
              title: const Text('Contact Us'),
              onTap:(){
                Navigator.pop(context);
              },
            ),
          ],
        ),
      ),
      floatingActionButton:FloatingActionButton(
        elevation: 10.0,
        child: const Icon(Icons.shop_2),
        onPressed: () {
          // ignore: avoid_print
          print('This is Floating Action Button');
        },
        backgroundColor: Colors.blueAccent.shade200,
        hoverColor: Colors.greenAccent.shade200,
      ),
      floatingActionButtonLocation: FloatingActionButtonLocation.endFloat,
      bottomNavigationBar: BottomNavigationBar(
        selectedItemColor: Colors.blueAccent,
        elevation: 10.0,
        iconSize: 30.0,
        backgroundColor:  const Color.fromARGB(255, 179, 238, 155),
        currentIndex: _selectedIndex,
        onTap: _onItemTap,
        showUnselectedLabels: false,
        unselectedItemColor: Colors.black,
        items: const [
            BottomNavigationBarItem(
            icon: Icon(Icons.home),
            label: 'Home',
          ),
          BottomNavigationBarItem(
            icon: Icon(Icons.shopping_bag),
            label: 'Products'
          ),
           BottomNavigationBarItem(
            icon: Icon(Icons.shopping_cart),
            label: 'Orders'
          ),
        ],),
    );
  }
}

